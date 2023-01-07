Imports entidad
Imports datos
Public Class classnegocio
    Dim dat As New classdatos
    Public Function listaproductos() As DataTable
        Return Dat.listaproductos
    End Function
    Public Function listaclientes() As DataTable
        Return dat.listaclientes
    End Function
    Public Function movimiento(ByVal ent As classentidad) As Integer
        Return dat.movimiento(ent)
    End Function
    Public Function stockproducto(ByVal ent As classentidad) As DataTable
        Return dat.stockproducto(ent)
    End Function
    Private Sub classnegocio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
