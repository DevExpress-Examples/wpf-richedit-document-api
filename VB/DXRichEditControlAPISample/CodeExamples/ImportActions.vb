Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace DXRichEditControlAPISample.CodeExamples

    Friend Class ImportActions

        Private Shared Sub ImportRtfText(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
'#Region "#ImportRtfText"
            Dim rtfString As String = "{\rtf1\ansi\ansicpg1252\deff0\deflang1049" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "{\fonttbl{\f0\fswiss\fprq2\fcharset0 Arial;}" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "{\f1\fswiss\fcharset0 Arial;}}" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "{\colortbl ;\red0\green0\blue255;}" & Global.Microsoft.VisualBasic.Constants.vbCrLf & "\viewkind4\uc1\pard\cf1\lang1033\b\f0\fs32 Test.\cf0\b0\f1\fs20\par}"
            document.RtfText = rtfString
'#End Region  ' #ImportRtfText
        End Sub
    End Class
End Namespace
