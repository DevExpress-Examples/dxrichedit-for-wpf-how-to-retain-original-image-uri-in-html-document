Imports System
Imports System.Windows
'#Region "#usings"
Imports DevExpress.Office.Utils
Imports DevExpress.Office.Services

'#End Region  ' #usings
Namespace Retain_Img_Src

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub richEditControl1_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ApplyTemplate()
            Me.richEditControl1.LoadDocument("test.htm")
            AddHandler Me.richEditControl1.ContentChanged, New EventHandler(AddressOf richEditControl1_ContentChanged)
        End Sub

        Private Sub richEditControl1_ContentChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.memoEdit1.Text = Me.richEditControl1.Document.GetHtmlText(Me.richEditControl1.Document.Range, New CustomUriProvider())
        End Sub

'#Region "#documentloaded"
        Private Sub richEditControl1_DocumentLoaded(ByVal sender As Object, ByVal e As EventArgs)
            Dim service As IUriProviderService = Me.richEditControl1.GetService(Of IUriProviderService)()
            If service IsNot Nothing Then
                service.RegisterProvider(New CustomUriProvider())
            End If
        End Sub
'#End Region  ' #documentloaded
    End Class

'#Region "#customuriprovider"
    Public Class CustomUriProvider
        Implements IUriProvider

'#Region "IUriProvider Members"
        Public Function CreateCssUri(ByVal rootUri As String, ByVal styleText As String, ByVal relativeUri As String) As String Implements IUriProvider.CreateCssUri
            Return String.Empty
        End Function

        Public Function CreateImageUri(ByVal rootUri As String, ByVal image As OfficeImage, ByVal relativeUri As String) As String Implements IUriProvider.CreateImageUri
            Return image.Uri
        End Function
'#End Region
    End Class
'#End Region  ' #customuriprovider
End Namespace
