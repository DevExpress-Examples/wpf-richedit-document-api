Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Drawing

Namespace DXRichEditControlAPISample.CodeExamples
	Public Module FormattingActions
		Private Sub FormatText(ByVal document As Document)
'			#Region "#FormatText"
			document.BeginUpdate()
			document.AppendText("Normal" & vbLf & "Formatted" & vbLf & "Normal")
			document.EndUpdate()
			Dim range As DocumentRange = document.Paragraphs(1).Range
			Dim cp As CharacterProperties = document.BeginUpdateCharacters(range)
			cp.FontName = "Comic Sans MS"
			cp.FontSize = 18
			cp.ForeColor = Color.Blue
			cp.BackColor = Color.Snow
			cp.Underline = UnderlineType.DoubleWave
			cp.UnderlineColor = Color.Red
			document.EndUpdateCharacters(cp)
'			#End Region ' #FormatText
		End Sub

		Private Sub ResetCharacterFormatting(ByVal document As Document)
'			#Region "#ResetCharacterFormatting"
			document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			' Set font size and font name of the characters in the first paragraph to default. 
			' Other character properties remain intact.
			Dim range As DocumentRange = document.Paragraphs(0).Range
			Dim cp As CharacterProperties = document.BeginUpdateCharacters(range)
			cp.Reset(CharacterPropertiesMask.FontSize Or CharacterPropertiesMask.FontName)
			document.EndUpdateCharacters(cp)
'			#End Region ' #ResetCharacterFormatting
		End Sub

		Private Sub FormatParagraph(ByVal document As Document)
'			#Region "#FormatParagraph"
			document.BeginUpdate()
			document.AppendText("Modified Paragraph" & vbLf & "Normal" & vbLf & "Normal")
			document.EndUpdate()
			Dim pos As DocumentPosition = document.Range.Start
			Dim range As DocumentRange = document.CreateRange(pos, 0)
			Dim pp As ParagraphProperties = document.BeginUpdateParagraphs(range)
			' Center paragraph
			pp.Alignment = ParagraphAlignment.Center
			' Set triple spacing
			pp.LineSpacingType = ParagraphLineSpacing.Multiple
			pp.LineSpacingMultiplier = 3
			' Set left indent at 0.5".
			' Default unit is 1/300 of an inch (a document unit).
			pp.LeftIndent = DevExpress.Office.Utils.Units.InchesToDocumentsF(0.5F)
			' Set tab stop at 1.5"
			Dim tbiColl As TabInfoCollection = pp.BeginUpdateTabs(True)
			Dim tbi As New TabInfo()
			tbi.Alignment = TabAlignmentType.Center
			tbi.Position = DevExpress.Office.Utils.Units.InchesToDocumentsF(1.5F)
			tbiColl.Add(tbi)
			pp.EndUpdateTabs(tbiColl)
			document.EndUpdateParagraphs(pp)
'			#End Region ' #FormatParagraph
		End Sub

		Private Sub ResetParagraphFormatting(ByVal document As Document)
			'			#Region "#ResetParagraphFormatting"
			document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			' Set alignment and indentation of the first line in the first paragraph to default. 
			' Other paragraph properties remain intact.
			Dim range As DocumentRange = document.Paragraphs(0).Range
			Dim cp As ParagraphProperties = document.BeginUpdateParagraphs(range)
			cp.Reset(ParagraphPropertiesMask.Alignment Or ParagraphPropertiesMask.FirstLineIndent)
			document.EndUpdateParagraphs(cp)
			'			#End Region ' #ResetParagraphFormatting
		End Sub
		Private Sub FormatParagraphBorders(ByVal document As Document)
			'			#Region "#FormatParagraphBorders"
			' Start to edit the document.
			document.BeginUpdate()

			' Append text to the document.
			document.AppendText(String.Format("Modified Paragraph" & Environment.NewLine & "Normal" & Environment.NewLine & "Normal"))

			' Finalize to edit the document.
			document.EndUpdate()

			' Obtain the first and last paragraph ranges
			Dim firstParagraph As Paragraph = document.Paragraphs(0)
			Dim thirdParagraph As Paragraph = document.Paragraphs(2)
			Dim paragraphRange As DocumentRange = document.CreateRange(firstParagraph.Range.Start, thirdParagraph.Range.End.ToInt() - firstParagraph.Range.Start.ToInt())

			' Start to edit the paragraph.
			Dim pp As ParagraphProperties = document.BeginUpdateParagraphs(paragraphRange)
			BorderHelper.SetBorder(pp.Borders.HorizontalBorder)
			BorderHelper.SetBorder(pp.Borders.BottomBorder)
			BorderHelper.SetBorder(pp.Borders.TopBorder)
			BorderHelper.SetBorder(pp.Borders.LeftBorder)
			BorderHelper.SetBorder(pp.Borders.RightBorder)

			' Finalize to edit the paragraph.
			document.EndUpdateParagraphs(pp)
			'			#End Region ' #FormatParagraphBorders
		End Sub
#Region "#@FormatParagraphBorders"
		Friend Class BorderHelper
			Public Shared Sub SetBorder(ByVal border As ParagraphBorder)
				border.LineWidth = 2.0F
				border.LineStyle = BorderLineStyle.Thick
				border.LineColor = Color.SteelBlue
			End Sub
		End Class
#End Region ' #@FormatParagraphBorders
	End Module
End Namespace
