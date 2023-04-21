'Imports para conexión.
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient


Public Class Datos
    'Conexión y elementos para la misma.
    Dim MiStringDeConexion = "Data Source=.\;Initial Catalog= Zorrito;Integrated Security=TRUE"
    Dim MiConexion As SqlConnection
    Dim MiDataSet As DataSet
    Dim MiSQLComand As SqlCommand
    Dim MiSQLAdapter As SqlDataAdapter
    Dim MiDataTable As DataTable

    Public Sub Ejecutar(ByVal Miconsulta As String)
        'Ejecución de consulta asignada mediante función.
        MiConexion = New SqlConnection(MiStringDeConexion)
        MiSQLComand = New SqlCommand(Miconsulta)
        MiSQLComand.Connection = MiConexion
        MiConexion.Open()
        MiSQLComand.ExecuteNonQuery()
        MiConexion.Close()
    End Sub


    Public Function Consultas(ByVal MiConsulta As String) As DataTable
        'Consulta que devuelve un DataTable con los datos obtenidos segun la consulta ("MiConsulta") asignada.
        MiConexion = New SqlConnection(MiStringDeConexion)
        MiSQLComand = New SqlCommand(MiConsulta)
        MiSQLComand.Connection = MiConexion
        MiConexion.Open()

        MiDataSet = New DataSet
        MiDataTable = New DataTable
        MiSQLAdapter = New SqlDataAdapter

        MiSQLAdapter.SelectCommand = MiSQLComand
        MiSQLAdapter.Fill(MiDataSet)

        MiDataTable = MiDataSet.Tables(0)
        MiConexion.Close()

        Return MiDataTable
    End Function
End Class


