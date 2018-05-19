#Region "#usings"
Imports DevExpress.Office.Services
Imports DevExpress.Office.Utils
Imports System
#End Region ' #usings

Namespace HTML_Export_ImageSourceExample
	#Region "#customuriprovider"
	Public Class CustomUriProvider
		Implements IUriProvider

		#Region "IUriProvider Members"
		Public Function CreateCssUri(ByVal rootUri As String, ByVal styleText As String, ByVal relativeUri As String) As String Implements IUriProvider.CreateCssUri
			Return String.Empty
		End Function

		Public Function CreateImageUri(ByVal rootUri As String, ByVal image As OfficeImage, ByVal relativeUri As String) As String Implements IUriProvider.CreateImageUri
			Return image.Uri
		End Function
		#End Region
	End Class
	#End Region ' #customuriprovider
End Namespace
