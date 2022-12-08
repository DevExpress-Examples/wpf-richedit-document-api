Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace DXRichEditControlAPISample.CodeExamples

    Friend Class FormFieldsActions

        Private Shared Sub CreateCheckbox(ByVal document As DevExpress.XtraRichEdit.API.Native.Document)
#Region "#CreateCheckbox"
            Dim currentPosition As DevExpress.XtraRichEdit.API.Native.DocumentPosition = document.CaretPosition
            Dim checkBox As DevExpress.XtraRichEdit.API.Native.CheckBox = document.FormFields.InsertCheckBox(currentPosition)
            checkBox.Name = "check1"
            checkBox.State = DevExpress.XtraRichEdit.API.Native.CheckBoxState.Checked
            checkBox.SizeMode = DevExpress.XtraRichEdit.API.Native.CheckBoxSizeMode.Auto
            checkBox.HelpTextType = DevExpress.XtraRichEdit.API.Native.FormFieldTextType.Custom
            checkBox.HelpText = "help text"
#End Region  ' #CreateCheckbox
        End Sub
    End Class
End Namespace
