Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Web

Namespace dragDropMvc.Models

	Public Class GridModel
		Private privateCategoryID As Integer
		Public Property CategoryID() As Integer
			Get
				Return privateCategoryID
			End Get
			Set(ByVal value As Integer)
				privateCategoryID = value
			End Set
		End Property
		Private privateCategoryName As String
		Public Property CategoryName() As String
			Get
				Return privateCategoryName
			End Get
			Set(ByVal value As String)
				privateCategoryName = value
			End Set
		End Property
		Private privateDescription As String
		Public Property Description() As String
			Get
				Return privateDescription
			End Get
			Set(ByVal value As String)
				privateDescription = value
			End Set
		End Property
	End Class

	Public Class DataProvider
		Private Const droppableSource As String = "firstDS"
		Private Const draggableSource As String = "secondDS"

		Public Function GetFirstGridData() As DataTable
			If HttpContext.Current.Session(draggableSource) Is Nothing Then
				Dim command = "SELECT CategoryID, CategoryName, Description FROM Categories"
				Dim connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & HttpContext.Current.Server.MapPath("~/App_Data/Categories + products.mdb")
				Dim adapter = New System.Data.OleDb.OleDbDataAdapter(command, connectionString)
				Dim dt = New DataTable()
				adapter.Fill(dt)
				HttpContext.Current.Session(draggableSource) = dt
			End If
			Return TryCast(HttpContext.Current.Session(draggableSource), DataTable)
		End Function
		Public Function GetSecondGridData() As DataTable
			If HttpContext.Current.Session(droppableSource) Is Nothing Then
				Dim dt = New DataTable()
				dt.Columns.Add("CategoryID", GetType(Int32))
				dt.Columns.Add("CategoryName", GetType(String))
				dt.Columns.Add("Description", GetType(String))
				HttpContext.Current.Session(droppableSource) = dt
			End If
			Return TryCast(HttpContext.Current.Session(droppableSource), DataTable)
		End Function
		Public Sub Update(ByVal key As Integer, ByVal leftToRight As Boolean)
			Dim source = If(leftToRight, GetFirstGridData(), GetSecondGridData())
			Dim target = If(leftToRight, GetSecondGridData(), GetFirstGridData())

			'update target datasource
			Dim sourceRow = source.AsEnumerable().Where(Function(x) x.Field(Of Int32)("CategoryID") = key).SingleOrDefault()
			target.ImportRow(sourceRow)

			'remove source data
			source.Rows.Remove(sourceRow)
		End Sub
	End Class
End Namespace