Imports DevExpress.Xpf.Grid
Imports System.Collections

Namespace DXRichEditControlAPISample

    Public Class CodeExampleGroupChildrenSelector
        Implements IChildNodesSelector

        Private Function SelectChildren(ByVal item As Object) As IEnumerable Implements IChildNodesSelector.SelectChildren
            If TypeOf item Is CodeExampleGroup Then Return CType(item, CodeExampleGroup).Examples
            Return Nothing
        End Function
    End Class
End Namespace
