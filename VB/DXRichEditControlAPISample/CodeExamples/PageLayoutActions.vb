﻿Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace DXRichEditControlAPISample.CodeExamples
	Friend Class PageLayoutActions
		Private Shared Sub LineNumbering(ByVal document As Document)
'			#Region "#LineNumbering"
			document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			document.Unit = DevExpress.Office.DocumentUnit.Inch
			Dim sec As Section = document.Sections(0)
			sec.LineNumbering.CountBy = 2
			sec.LineNumbering.Start = 1
			sec.LineNumbering.Distance = 0.25F
			sec.LineNumbering.RestartType = LineNumberingRestart.NewSection
'			#End Region ' #LineNumbering
		End Sub

		Private Shared Sub CreateColumns(ByVal document As Document)
'			#Region "#CreateColumns"
			document.LoadDocument("Documents//Grimm.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			document.Unit = DevExpress.Office.DocumentUnit.Inch
			' Get the first section in a document
			Dim firstSection As Section = document.Sections(0)
			' Create columns and apply them to the document
			Dim sectionColumnsLayout As SectionColumnCollection = firstSection.Columns.CreateUniformColumns(firstSection.Page, 0.2F, 3)
			firstSection.Columns.SetColumns(sectionColumnsLayout)
'			#End Region ' #CreateColumns
		End Sub

		Private Shared Sub PrintLayout(ByVal document As Document)
'			#Region "#PrintLayout"
			document.Unit = DevExpress.Office.DocumentUnit.Inch
			document.Sections(0).Page.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A6
			document.Sections(0).Page.Landscape = True
			document.Sections(0).Margins.Left = 2.0F
'			#End Region ' #PrintLayout
		End Sub

		Private Shared Sub TabStops(ByVal document As Document)
'			#Region "#TabStops"
			document.Unit = DevExpress.Office.DocumentUnit.Inch
			Dim tabs As TabInfoCollection = document.Paragraphs(0).BeginUpdateTabs(True)
			Dim tab1 As New DevExpress.XtraRichEdit.API.Native.TabInfo()
			' Sets tab stop at 2.5 inch
			tab1.Position = 2.5F
			tab1.Alignment = TabAlignmentType.Left
			tab1.Leader = TabLeaderType.MiddleDots
			tabs.Add(tab1)
			Dim tab2 As New DevExpress.XtraRichEdit.API.Native.TabInfo()
			tab2.Position = 5.5F
			tab2.Alignment = TabAlignmentType.Decimal
			tab2.Leader = TabLeaderType.EqualSign
			tabs.Add(tab2)
			document.Paragraphs(0).EndUpdateTabs(tabs)
'			#End Region ' #TabStops
		End Sub
	End Class
End Namespace
