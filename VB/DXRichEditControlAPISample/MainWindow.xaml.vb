Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Grid
Imports DevExpress.XtraRichEdit.API.Native
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Windows

Namespace DXRichEditControlAPISample

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Private codeEditor As ExampleCodeEditor

        Private evaluator As ExampleEvaluatorByTimer

        Private projectLanguage As ExampleLanguage

        Private richEditControlVBLoaded As Boolean = False

        Private richEditControlCsLoaded As Boolean = False

        'CultureInfo defaultCulture = new CultureInfo("en-US");
        Public Sub New()
            Me.InitializeComponent()
            Dim examplePath As String = "CodeExamples"
            Dim examplesCS As Dictionary(Of String, FileInfo) = GatherExamplesFromProject(examplePath, ExampleLanguage.Csharp)
            Dim examplesVB As Dictionary(Of String, FileInfo) = GatherExamplesFromProject(examplePath, ExampleLanguage.VB)
            DisableTabs(examplesCS.Count, examplesVB.Count)
            Dim examples As List(Of CodeExampleGroup) = FindExamples(examplePath, examplesCS, examplesVB)
            Me.ShowExamplesInTreeList(Me.treeList1, examples)
            AddHandler Me.richEditControlCS.Loaded, AddressOf Me.richEditControlCS_Loaded
            AddHandler Me.richEditControlVB.Loaded, AddressOf Me.richEditControlVB_Loaded
            evaluator = New RichEditExampleEvaluatorByTimer()
            AddHandler evaluator.QueryEvaluate, AddressOf OnExampleEvaluatorQueryEvaluate
            AddHandler evaluator.OnBeforeCompile, AddressOf evaluator_OnBeforeCompile
            AddHandler evaluator.OnAfterCompile, AddressOf evaluator_OnAfterCompile
        End Sub

        Private Sub evaluator_OnAfterCompile(ByVal sender As Object, ByVal args As OnAfterCompileEventArgs)
            If codeEditor IsNot Nothing Then codeEditor.AfterCompile(args.Result)
        End Sub

        Private Sub evaluator_OnBeforeCompile(ByVal sender As Object, ByVal args As EventArgs)
            Dim document As Document = Me.richEditControl.Document
            document.BeginUpdate()
            codeEditor.BeforeCompile()
            Me.richEditControl.CreateNewDocument()
            document.Unit = DevExpress.Office.DocumentUnit.Document
            document.EndUpdate()
        End Sub

        Private Sub richEditControlCS_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If richEditControlVBLoaded AndAlso Not richEditControlCsLoaded Then CreateCodeEditor()
            richEditControlCsLoaded = True
        End Sub

        Private Sub richEditControlVB_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If richEditControlCsLoaded AndAlso Not richEditControlVBLoaded Then CreateCodeEditor()
            richEditControlVBLoaded = True
        End Sub

        Private Sub DisableTabs(ByVal examplesCSCount As Integer, ByVal examplesVBCount As Integer)
            If examplesCSCount = 0 Then
                For Each t As DXTabItem In Me.tabControl.Items
                    If t.Header.ToString().StartsWith("CS") Then t.IsEnabled = False
                Next
            End If

            If examplesVBCount = 0 Then
                For Each t As DXTabItem In Me.tabControl.Items
                    If t.Header.ToString().StartsWith("VB") Then t.IsEnabled = False
                Next
            End If
        End Sub

        Private Sub CreateCodeEditor()
            System.Diagnostics.Debug.Assert(codeEditor Is Nothing)
            codeEditor = New ExampleCodeEditor(Me.richEditControlCS, Me.richEditControlVB, Me.richEditControlCSClass, Me.richEditControlVBClass)
            codeEditor.CurrentExampleLanguage = CurrentExampleLanguage
            ShowFirstExample()
        End Sub

        Private Sub ShowExamplesInTreeList(ByVal treeList1 As TreeListControl, ByVal examples As List(Of CodeExampleGroup))
            treeList1.ItemsSource = examples
        End Sub

        Private Sub ShowFirstExample()
            projectLanguage = DetectExampleLanguage("DXRichEditControlAPISample")
            If projectLanguage = ExampleLanguage.Csharp Then
                Me.tabControl.SelectedIndex = 0
            Else
                Me.tabControl.SelectedIndex = 1
            End If

            Me.treeList1.View.ExpandAllNodes()
            If Me.treeList1.View.Nodes.Count > 0 Then Me.treeList1.View.FocusedNode = Me.treeList1.View.Nodes(0).Nodes.First()
        End Sub

        Public Property CurrentExampleLanguage As ExampleLanguage
            Get
                If Me.tabControl.SelectedContainer.Header.ToString().StartsWith("CS") Then
                    Return ExampleLanguage.Csharp
                Else
                    Return ExampleLanguage.VB
                End If
            End Get

            Set(ByVal value As ExampleLanguage)
                If codeEditor IsNot Nothing Then
                    codeEditor.CurrentExampleLanguage = value
                End If
            End Set
        End Property

        Private Sub OnNewExampleSelected(ByVal sender As Object, ByVal e As CurrentItemChangedEventArgs)
            Dim newExample As CodeExample = TryCast(e.NewItem, CodeExample)
            Dim oldExample As CodeExample = TryCast(e.OldItem, CodeExample)
            If newExample Is Nothing Then Return
            If codeEditor Is Nothing Then Return
            Dim exampleCode As String = codeEditor.ShowExample(oldExample, newExample)
            Me.codeExampleNameLbl.Content = ConvertStringToMoreHumanReadableForm(newExample.RegionName) & " example"
            Dim args As CodeEvaluationEventArgs = New CodeEvaluationEventArgs()
            InitializeCodeEvaluationEventArgs(args)
            evaluator.ForceCompile(args)
            If Equals(newExample.HumanReadableGroupName, "Comments Actions") Then
                Me.richEditControl.Options.Comments.Visibility = DevExpress.XtraRichEdit.RichEditCommentVisibility.Visible
            Else
                Me.richEditControl.Options.Comments.Visibility = DevExpress.XtraRichEdit.RichEditCommentVisibility.Hidden
            End If
        End Sub

        Private Sub InitializeCodeEvaluationEventArgs(ByVal e As CodeEvaluationEventArgs)
            e.Result = True
            If codeEditor Is Nothing Then Return
            e.Code = codeEditor.CurrentCodeEditor.Text
            e.CodeClasses = codeEditor.CurrentCodeClassEditor.Text
            e.Language = CurrentExampleLanguage
            e.EvaluationParameter = Me.richEditControl.Document
        End Sub

        Private Sub OnExampleEvaluatorQueryEvaluate(ByVal sender As Object, ByVal e As CodeEvaluationEventArgs)
            e.Result = False
            If codeEditor IsNot Nothing AndAlso codeEditor.RichEditTextChanged Then
                Dim span As TimeSpan = Date.Now - codeEditor.LastExampleCodeModifiedTime
                If span < TimeSpan.FromMilliseconds(1000) Then
                    codeEditor.ResetLastExampleModifiedTime()
                    Return
                End If

                InitializeCodeEvaluationEventArgs(e)
            End If
        End Sub

        Private Sub tabControl_SelectionChanged(ByVal sender As Object, ByVal e As TabControlSelectionChangedEventArgs)
            CurrentExampleLanguage = If((CType(e.NewSelectedItem, DXTabItem).Header.ToString().StartsWith("CS")), ExampleLanguage.Csharp, ExampleLanguage.VB)
        End Sub

        Private Sub view_CustomColumnDisplayText(ByVal sender As Object, ByVal e As TreeList.TreeListCustomColumnDisplayTextEventArgs)
            If e.Node.HasChildren AndAlso TypeOf e.Node.Content Is CodeExampleGroup Then
                e.DisplayText = TryCast(e.Node.Content, CodeExampleGroup).Name
            End If
        End Sub
    End Class
End Namespace
