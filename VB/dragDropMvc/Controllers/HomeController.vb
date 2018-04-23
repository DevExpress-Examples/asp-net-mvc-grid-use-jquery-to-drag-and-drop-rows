Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports dragDropMvc.Models

Namespace dragDropMvc.Controllers
	Public Class HomeController
		Inherits Controller
		Private provider As New DataProvider()

		Public Function Index() As ActionResult
			Return View()
		End Function

		Public Function CallbackPanelPartial(ByVal key? As Integer, ByVal leftToRight? As Boolean) As ActionResult
			If key.HasValue Then
				provider.Update(Convert.ToInt32(key),Convert.ToBoolean(leftToRight))
			End If
			Return PartialView("_CallbackPanelPartial")
		End Function

		Public Function GridOne() As ActionResult
			Return PartialView("_GridOne", provider.GetFirstGridData())
		End Function
		Public Function GridTwo() As ActionResult
			Return PartialView("_GridTwo", provider.GetSecondGridData())
		End Function
	End Class
End Namespace