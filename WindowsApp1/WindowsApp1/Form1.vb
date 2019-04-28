Option Explicit On
Imports System.Drawing.Color
Imports System.Math
Public Class Form1
    Const Pi = 3.14
    Dim x As Single
    Dim y As Single
    Dim x0 As Single
    Dim y0 As Single
    Dim v As Single
    Dim v0 As Single
    Dim vx0 As Single
    Dim vy0 As Single
    Dim vx As Single
    Dim vy As Single
    Dim alpha As Single
    Dim alpha0 As Single
    Dim ax As Single
    Dim ay As Single
    Dim t As Single
    Dim dt As Single
    Dim PixColor As Color
    Dim Xmax As Single
    Dim Ymax As Single
    Dim Vmax As Single
    Private Axis1 As Object

    Private Sub InitAxis()
        Axis1.Axis_Type = 3
        Axis1.Pix_type = 1
        Axis1.x_Base = Val(TextBox2.Text)
        Axis1.y_Base = Val(TextBox3.Text)
        Axis1.Pix_type = 3
        Axis1.Pix_Size = 0.05
        Axis1.x_Name = "X"
        Axis1.y_Name = "Y"
        Axis1.BackColor = White
        Axis1.AxisDraw()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        alpha0 = Val(TextBox5.Text)
        v0 = Val(TextBox4.Text)
        dt = Val(TextBox6.Text)
        t = 0
        v = v0
        vx0 = v0 * Cos(alpha0 * Pi / 180)
        vy0 = v0 * Sin(alpha0 * Pi / 180)
        x0 = 0
        y0 = Val(TextBox1.Text)
        Vmax = v0
        Xmax = x0
        Ymax = y0
        Timer1.Enabled = True
    End Sub

        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        t = t + dt
        If RadioButton1.Checked Then
            ax = -v * vx
            ay = -1 - v * vy
            PixColor = Black
        Else
            ax = 0
            ay = -1
            PixColor = Red
        End If
        vx = vx0 + ax * dt
        vy = vy0 + ay * dt
        x = x0 + (vx0 + vx) * dt + ax * dt * dt / 2
        y = y0 + (vy0 + vy) * dt + ay * dt * dt / 2

        Axis1.Pix_Size = 0.005
        Axis1.PixDraw(x, y, PixColor, 1)
        Axis1.StatToDin()
        'ядро
        Axis1.Pix_Size = 0.02
        Axis1.PixDraw(x, y, PixColor, 2)
        Axis1.DinToPic()
        If y < 0 Then
            Timer1.Enabled = False
            TextBox7.Text = Str(Round(Xmax, 2))
            TextBox8.Text = Str(Round(Ymax, 2))
            TextBox9.Text = Str(Round(Vmax, 2))
        End If

        x0 = x
        y0 = y
        vx0 = vx
        vy0 = vy
        v = Sqrt(vx ^ 2 + vy ^ 2)
        If Abs(x) > Xmax Then Xmax = Abs(x)
        If Abs(y) > Ymax Then Ymax = Abs(y)
        If v > Vmax Then Vmax = v
        TextBox10.Text = Str(Round(t, 2))
    End Sub
End Class
