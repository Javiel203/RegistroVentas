Imports entidad
Imports negocios
Public Class Form1
    Dim ent As New classentidad
    Dim neg As New classnegocio
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = neg.listaproductos
        cboclientes.DataSource = neg.listaclientes
        cboclientes.DisplayMember = "NombreContacto"
        cboclientes.ValueMember = "idcliente"

        cboproductos.DataSource = neg.listaproductos
        cboproductos.DisplayMember = "nombreproducto"
        cboproductos.ValueMember = "idproducto"

    End Sub

    Private Sub cboproductos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboproductos.SelectedIndexChanged
        Try
            ent.producto = cboproductos.SelectedValue
            Dim tbl As DataTable = neg.stockproducto(ent)
            TextBox1.Text = tbl.Rows(0)(6)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If rdbsalida.Checked Then 'SALIDA DE `PRODUCTO
            If NumericUpDown1.Value > Val(TextBox1.Text) Then
                MsgBox("CANTIDAD ES MAYOR AL STOCK")
            Else
                ent.movimiento = 10
                ent.producto = cboproductos.SelectedValue()
                ent.cliente = cboclientes.SelectedValue()
                ent.empleado = 1 'DEBER IR CODIGO DE QUE SE LOGUEO
                ent.cantidad = NumericUpDown1.Value
                neg.movimiento(ent)
                DataGridView1.DataSource = neg.listaproductos
            End If
        ElseIf rdbsalida.Checked Then
            ent.movimiento = 11
            ent.producto = cboproductos.SelectedValue()
            ent.cliente = cboclientes.SelectedValue()
            ent.empleado = 1 'DEBER IR CODIGO DE QUE SE LOGUEO
            ent.cantidad = NumericUpDown1.Value
            neg.movimiento(ent)
            DataGridView1.DataSource = neg.listaproductos
        Else 'CAMBIAR PRODUCTO
            If NumericUpDown1.Value > Val(TextBox1.Text) Then
                MsgBox("CANTIDAD A CAMBIAR ES MAYOR AL STOCK")
            Else
                ent.movimiento = 12
                ent.producto = cboproductos.SelectedValue()
                ent.cliente = cboclientes.SelectedValue()
                ent.empleado = 1 'DEBER IR CODIGO DE QUE SE LOGUEO
                ent.cantidad = NumericUpDown1.Value
                neg.movimiento(ent)
                DataGridView1.DataSource = neg.listaproductos
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class