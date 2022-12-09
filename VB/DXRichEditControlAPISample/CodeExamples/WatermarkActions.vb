Imports DevExpress.XtraRichEdit.API.Native

Friend Class WatermarkActions
	Private Shared Sub CreateTextWatermark(ByVal document As Document)
		'			#Region "#CreateTextWatermark"
		'Check whether the document sections have headers:
		For Each section As Section In document.Sections
			If Not section.HasHeader(HeaderFooterType.Primary) Then
				'If not, create an empty header
				Dim header As SubDocument = section.BeginUpdateHeader()
				section.EndUpdateHeader(header)
			End If
		Next section
		Dim textWatermarkOptions As New TextWatermarkOptions()
		textWatermarkOptions.Color = System.Drawing.Color.LightGray
		textWatermarkOptions.FontFamily = "Calibri"
		textWatermarkOptions.Layout = WatermarkLayout.Horizontal
		textWatermarkOptions.Semitransparent = True

		document.WatermarkManager.SetText("CONFIDENTIAL", textWatermarkOptions)
		'			#End Region ' #CreateTextWatermark
	End Sub
	Private Shared Sub CreateImageWatermark(ByVal document As Document)
		'			#Region "#CreateImageWatermark"
		'Check whether the document sections have headers:
		For Each section As Section In document.Sections
			If Not section.HasHeader(HeaderFooterType.Primary) Then
				'If not, create an empty header
				Dim header As SubDocument = section.BeginUpdateHeader()
				section.EndUpdateHeader(header)
			End If
		Next section

		Dim imageWatermarkOptions As New ImageWatermarkOptions()
		imageWatermarkOptions.Washout = False
		imageWatermarkOptions.Scale = 2
		document.WatermarkManager.SetImage(System.Drawing.Image.FromFile("beverages.png"), imageWatermarkOptions)
		'			#End Region ' #CreateImageWatermark

	End Sub

End Class

