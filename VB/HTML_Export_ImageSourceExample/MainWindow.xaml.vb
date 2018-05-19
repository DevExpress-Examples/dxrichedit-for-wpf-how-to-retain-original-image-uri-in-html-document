Imports System
Imports System.Windows
#Region "#usings"
Imports DevExpress.Office.Services
Imports DevExpress.XtraRichEdit.API.Native
#End Region ' #usings

Namespace HTML_Export_ImageSourceExample
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub richEditControl1_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			richEditControl1.CreateNewDocument()
			richEditControl1.Document.Images.Append(DocumentImageSource.FromUri("http://www.devexpress.com/Support/Center/Attachment/GetAttachmentFile/e71fc07d-1c4e-4e08-a9be-65eb6f409c8b", Nothing))
			embedImagesCheck.EditValue = True
			AddHandler richEditControl1.ContentChanged, AddressOf richEditControl1_ContentChanged
		End Sub
		Private Sub richEditControl1_ContentChanged(ByVal sender As Object, ByVal e As EventArgs)
			ReloadHtml()
		End Sub

		Private Sub ReloadHtml()
'			#Region "#GetHtmlText"
			Dim exportOptions As New DevExpress.XtraRichEdit.Export.HtmlDocumentExporterOptions()
			exportOptions.EmbedImages = CBool(embedImagesCheck.IsChecked)
			Dim sText As String = richEditControl1.Document.GetHtmlText(richEditControl1.Document.Range, New CustomUriProvider(), exportOptions)
'			#End Region ' #GetHtmlText
			memoEdit1.Text = sText
		End Sub
		#Region "#documentloaded"
		Private Sub richEditControl1_DocumentLoaded(ByVal sender As Object, ByVal e As EventArgs)
			Dim service As IUriProviderService = richEditControl1.GetService(Of IUriProviderService)()
			If service IsNot Nothing Then
				service.RegisterProvider(New CustomUriProvider())
			End If
		End Sub
		#End Region ' #documentloaded

		Private Sub embedImagesCheck_EditValueChanged(ByVal sender As Object, ByVal e As DevExpress.Xpf.Editors.EditValueChangedEventArgs)
			If CBool(e.NewValue) = False Then
				textBlock.Text = "The CustomUriProvider.CreateImageUri method is called to write the original image uri."
			Else
				textBlock.Text = "CustomUriProvider is idle."
			End If
			ReloadHtml()
		End Sub
	End Class
End Namespace
