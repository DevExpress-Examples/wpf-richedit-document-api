<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128607952/23.1.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T213968)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Rich Text Editor API – How to Process Word Documents in Code

The [WPF Rich Text Editor Control](https://www.devexpress.com/products/net/controls/wpf/rich_editor/) allows you to deliver Microsoft Word-inspired functionality with ease. It includes comprehensive text formatting options, supports mail merge, and ships with a rich collection of end-user options you can use to create high-impact document processing solutions.

This example demonstrates how to use the Rich Text Editor to execute the following actions:

- Create, load, merge, split, save, and print documents
- Save a document in PDF and HTML formats
- Convert an HTML file to PDF and DOCX formats
- Format a document
- Manage document elements (paragraphs, lists, tables, shapes, pictures, headers, footers, notes, bookmarks, hyperlinks, and comments)
- Insert and modify fields
- Configure page layout settings
- Specify the built-in and custom document properties
- Protect and unprotect a document
- Create character, paragraph, and linked styles
- Import formatted text to a document
- Add checkbox form fields to a document
- Embed arbitrary XML data (custom XML parts) in a document

The application’s form contains the list of supported operations and editors that display the code and the result of these operations. A user can select an operation to view its code and result.

# Files to Look At

* [BookmarksAndHyperlinksActions](./CS/DXRichEditControlAPISample/CodeExamples/BookmarksAndHyperlinksActions.cs) (VB: [BookmarksAndHyperlinksActions](./VB/DXRichEditControlAPISample/CodeExamples/BookmarksAndHyperlinksActions.vb))
* [CommentsActions](./CS/DXRichEditControlAPISample/CodeExamples/CommentsActions.cs) (VB: [CommentsActions](./VB/DXRichEditControlAPISample/CodeExamples/CommentsActions.vb))
* [CustomXmlActions](./CS/DXRichEditControlAPISample/CodeExamples/CustomXmlActions.cs) (VB: [CustomXmlActions](./VB/DXRichEditControlAPISample/CodeExamples/CustomXmlActions.vb))
* [DocumentPropertiesActions](./CS/DXRichEditControlAPISample/CodeExamples/DocumentPropertiesActions.cs) (VB: [DocumentPropertiesActions](./VB/DXRichEditControlAPISample/CodeExamples/DocumentPropertiesActions.vb))
* [ExportActions](./CS/DXRichEditControlAPISample/CodeExamples/ExportActions.cs) (VB: [ExportActions](./VB/DXRichEditControlAPISample/CodeExamples/ExportActions.vb))
* [DocumentFieldActions](./CS/DXRichEditControlAPISample/CodeExamples/DocumentFieldActions.cs) (VB: [DocumentFieldActions](./VB/DXRichEditControlAPISample/CodeExamples/DocumentFieldActions.vb))
* [FormattingActions](./CS/DXRichEditControlAPISample/CodeExamples/FormattingActions.cs) (VB: [FormattingActions](./VB/DXRichEditControlAPISample/CodeExamples/FormattingActions.vb))
* [FormFieldsActions](./CS/DXRichEditControlAPISample/CodeExamples/FormFieldsActions.cs) (VB: [FormFieldsActions](./VB/DXRichEditControlAPISample/CodeExamples/FormFieldsActions.vb))
* [HeaderAndFooterActions](./CS/DXRichEditControlAPISample/CodeExamples/HeaderAndFooterActions.cs) (VB: [HeaderAndFooterActions](./VB/DXRichEditControlAPISample/CodeExamples/HeaderAndFooterActions.vb))
* [ImportActions](./CS/DXRichEditControlAPISample/CodeExamples/ImportActions.cs) (VB: [ImportActions](./VB/DXRichEditControlAPISample/CodeExamples/ImportActions.vb))
* [InlinePicturesActions](./CS/DXRichEditControlAPISample/CodeExamples/InlinePicturesActions.cs) (VB: [InlinePicturesActions](./VB/DXRichEditControlAPISample/CodeExamples/InlinePicturesActions.vb))
* [ListActions](./CS/DXRichEditControlAPISample/CodeExamples/ListActions.cs) (VB: [ListActions](./VB/DXRichEditControlAPISample/CodeExamples/ListActions.vb))
* [NotesActions](./CS/DXRichEditControlAPISample/CodeExamples/NotesActions.cs) (VB: [NotesActions](./VB/DXRichEditControlAPISample/CodeExamples/NotesActions.vb))
* [PageLayoutActions](./CS/DXRichEditControlAPISample/CodeExamples/PageLayoutActions.cs) (VB: [PageLayoutActions](./VB/DXRichEditControlAPISample/CodeExamples/PageLayoutActions.vb))
* [RangeActions](./CS/DXRichEditControlAPISample/CodeExamples/RangeActions.cs) (VB: [RangeActions](./VB/DXRichEditControlAPISample/CodeExamples/RangeActions.vb))
* [SearchAndReplaceActions](./CS/DXRichEditControlAPISample/CodeExamples/SearchAndReplaceActions.cs) (VB: [SearchAndReplaceActions](./VB/DXRichEditControlAPISample/CodeExamples/SearchAndReplaceActions.vb))
* [ShapesActions](./CS/DXRichEditControlAPISample/CodeExamples/ShapesActions.cs) (VB: [ShapesActions](./VB/DXRichEditControlAPISample/CodeExamples/ShapesActions.vb))
* [StylesActions](./CS/DXRichEditControlAPISample/CodeExamples/StylesActions.cs) (VB: [StylesActions](./VB/DXRichEditControlAPISample/CodeExamples/StylesActions.vb))
* [TableActions](./CS/DXRichEditControlAPISample/CodeExamples/TableActions.cs) (VB: [TableActions](./VB/DXRichEditControlAPISample/CodeExamples/TableActions.vb))
* [WatermarkActions](./CS/DXRichEditControlAPISample/CodeExamples/WatermarkActions.cs) (VB: [WatermarkActions](./VB/DXRichEditControlAPISample/CodeExamples/WatermarkActions.vb))

# Documentation

* [RichEditControl Document](https://docs.devexpress.com/WPF/9115/controls-and-libraries/rich-text-editor/rich-edit-control-document)
* [Fields in RichEditControl Document](https://docs.devexpress.com/WPF/10296/controls-and-libraries/rich-text-editor/fields)
* [Text Formatting](https://docs.devexpress.com/WPF/118199/controls-and-libraries/rich-text-editor/text-formatting)
* [WPF Rich Text Editor Examples](https://docs.devexpress.com/WPF/9139/controls-and-libraries/rich-text-editor/examples)

# More Examples

* [WinForms Rich Text Editor API – How to Process Word Documents in Code](https://github.com/DevExpress-Examples/winforms-richedit-document-api)
* [Word Processing Document API – How to Process Word Documents in Code](https://github.com/DevExpress-Examples/word-document-api-examples)
