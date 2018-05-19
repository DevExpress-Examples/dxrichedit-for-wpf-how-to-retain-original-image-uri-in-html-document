Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
#Region "#usings"
Imports DevExpress.XtraRichEdit.Utils
Imports DevExpress.Office.Utils
Imports DevExpress.Office.Services
#End Region ' #usings

Namespace Retain_Img_Src
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub richEditControl1_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			ApplyTemplate()
			richEditControl1.LoadDocument("test.htm")
			AddHandler richEditControl1.ContentChanged, AddressOf richEditControl1_ContentChanged
		End Sub
		Private Sub richEditControl1_ContentChanged(ByVal sender As Object, ByVal e As EventArgs)
			memoEdit1.Text = richEditControl1.Document.GetHtmlText(richEditControl1.Document.Range, New CustomUriProvider())
		End Sub
		#Region "#documentloaded"
		Private Sub richEditControl1_DocumentLoaded(ByVal sender As Object, ByVal e As EventArgs)
			Dim service As IUriProviderService = richEditControl1.GetService(Of IUriProviderService)()
			If service IsNot Nothing Then
				service.RegisterProvider(New CustomUriProvider())
			End If
		End Sub
		#End Region ' #documentloaded
	End Class
	#Region "#customuriprovider"
	Public Class CustomUriProvider
		Implements IUriProvider
		#Region "IUriProvider Members"
		Public Function CreateCssUri(ByVal rootUri As String, ByVal styleText As String, ByVal relativeUri As String) As String _
Implements  IUriProvider.CreateCssUri
			Return String.Empty
		End Function

		Public Function CreateImageUri(ByVal rootUri As String, ByVal image As OfficeImage, ByVal relativeUri As String) As String _
Implements  IUriProvider.CreateImageUri
			Return image.Uri
		End Function
		#End Region
	End Class
	#End Region ' #customuriprovider
End Namespace
