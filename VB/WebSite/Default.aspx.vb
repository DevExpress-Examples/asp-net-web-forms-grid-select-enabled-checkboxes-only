Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Private Function getRowEnabledStatus(ByVal VisibleIndex As Integer) As Boolean
		Dim CategoryID As Integer = Convert.ToInt32(grid.GetRowValues(VisibleIndex, "CategoryID"))

		Return If(CategoryID <> 2, True, False)
	End Function

	Protected Sub grid_CommandButtonInitialize(ByVal sender As Object, ByVal e As ASPxGridViewCommandButtonEventArgs)
		If e.ButtonType <> ColumnCommandButtonType.SelectCheckbox Then
			Return
		End If

		Dim rowEnabled As Boolean = getRowEnabledStatus(e.VisibleIndex)
		e.Enabled = rowEnabled
	End Sub
	Protected Sub grid_CustomJSProperties(ByVal sender As Object, ByVal e As ASPxGridViewClientJSPropertiesEventArgs)
		Dim indexesUnselected As List(Of Integer) = TryCast(Session("WebManagement_IndexesUnselected"), List(Of Integer))
		Dim indexesSelected As List(Of Integer) = TryCast(Session("WebManagement_IndexesSelected"), List(Of Integer))
		e.Properties("cpIndexesUnselected") = indexesUnselected
		e.Properties("cpIndexesSelected") = indexesSelected
	End Sub
	Protected Sub cbAll_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim indexesUnselected As New List(Of Integer)()
		Dim indexesSelected As New List(Of Integer)()

		For i As Integer = 0 To grid.VisibleRowCount - 1
			Dim rowEnabled As Boolean = getRowEnabledStatus(i)
			If rowEnabled Then
				indexesSelected.Add(i)
			Else
				indexesUnselected.Add(i)
			End If
		Next i
		Session("WebManagement_IndexesUnselected") = indexesUnselected
		Session("WebManagement_IndexesSelected") = indexesSelected
	End Sub
	Protected Sub grid_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
		For i As Integer = 0 To grid.VisibleRowCount - 1
			Dim rowEnabled As Boolean = getRowEnabledStatus(i)

			If rowEnabled AndAlso e.Parameters = "true" Then
				grid.Selection.SelectRow(i)
			Else
				grid.Selection.UnselectRow(i)
			End If
		Next i
	End Sub
	Protected Sub grid_DataBound(ByVal sender As Object, ByVal e As EventArgs)
		grid.JSProperties("cpPageSize") = grid.SettingsPager.PageSize
	End Sub

	Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
		grid.Selection.SelectAll()
	End Sub
End Class