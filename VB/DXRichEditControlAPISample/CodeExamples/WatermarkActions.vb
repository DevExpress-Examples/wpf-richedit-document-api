Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.XtraRichEdit.API.Native
Imports System.Drawing

Namespace DXRichEditControlAPISample.CodeExamples

    Friend Class WatermarkActions

        Private Shared Sub CreateTextWatermark(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#CreateTextWatermark"
            'Check whether the document sections have headers:
            For Each section As DevExpress.XtraRichEdit.API.Native.Section In document.Sections
                If Not section.HasHeader(DevExpress.XtraRichEdit.API.Native.HeaderFooterType.Primary) Then
                    'If not, create an empty header
                    Dim header As DevExpress.XtraRichEdit.API.Native.SubDocument = section.BeginUpdateHeader()
                    section.EndUpdateHeader(header)
                End If
            Next

            Dim textWatermarkOptions As DevExpress.XtraRichEdit.API.Native.TextWatermarkOptions = New DevExpress.XtraRichEdit.API.Native.TextWatermarkOptions()
            textWatermarkOptions.Color = System.Drawing.Color.LightGray
            textWatermarkOptions.FontFamily = "Calibri"
            textWatermarkOptions.Layout = DevExpress.XtraRichEdit.API.Native.WatermarkLayout.Horizontal
            textWatermarkOptions.Semitransparent = True
            document.WatermarkManager.SetText("CONFIDENTIAL", textWatermarkOptions)
#End Region  ' #CreateTextWatermark
        End Sub

        Private Shared Sub CreateImageWatermark(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#CreateImageWatermark"
            'Check whether the document sections have headers:
            For Each section As DevExpress.XtraRichEdit.API.Native.Section In document.Sections
                If Not section.HasHeader(DevExpress.XtraRichEdit.API.Native.HeaderFooterType.Primary) Then
                    'If not, create an empty header
                    Dim header As DevExpress.XtraRichEdit.API.Native.SubDocument = section.BeginUpdateHeader()
                    section.EndUpdateHeader(header)
                End If
            Next

            Dim imageWatermarkOptions As DevExpress.XtraRichEdit.API.Native.ImageWatermarkOptions = New DevExpress.XtraRichEdit.API.Native.ImageWatermarkOptions()
            imageWatermarkOptions.Washout = False
            imageWatermarkOptions.Scale = 2
            document.WatermarkManager.SetImage(System.Drawing.Image.FromFile("Documents//DevExpress.png"), imageWatermarkOptions)
#End Region  ' #CreateImageWatermark
        End Sub
    End Class
End Namespace
