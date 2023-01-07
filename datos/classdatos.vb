Imports System.Data.SqlClient
Imports entidad

Public Class classdatos
    Dim con As New SqlConnection(My.Settings.cadena)

    Public Function listaproductos() As DataTable
        Dim da As New SqlDataAdapter("usp_ListarProductos", con)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function
    Public Function listaclientes() As DataTable
        Dim da As New SqlDataAdapter("listaclientes", con)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function
    Public Function movimiento(ByVal ent As classentidad) As Integer
        Dim cmd As New SqlCommand("movimiento", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@idproducto", ent.producto)
        cmd.Parameters.AddWithValue("@idcliente", ent.cliente)
        cmd.Parameters.AddWithValue("@idempleado", ent.empleado)
        cmd.Parameters.AddWithValue("@cantidad", ent.cantidad)
        cmd.Parameters.AddWithValue("@movimiento", ent.movimiento)
        con.Open()
        Dim resp As Integer = cmd.ExecuteNonQuery
        con.Close()
        Return resp
    End Function
    Public Function stockproducto(ByVal ent As classentidad) As DataTable
        Dim cmd As New SqlCommand("sp_StockProductos", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@prod", ent.producto)
        Dim da As New SqlDataAdapter(cmd)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function
    Private Sub classdatos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
