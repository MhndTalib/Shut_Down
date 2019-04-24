Public Class Form1
    Dim sec As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (RadioButton1.Checked And TextBox1.Text.Trim() = "") Then
            MsgBox("يرجى إدخال عدد الدقائق أولاً", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading, "المبرمج مهند")
            TextBox1.Focus()
        Else
            RunCMD("S")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (RadioButton1.Checked And TextBox1.Text.Trim() = "") Then
            MsgBox("يرجى إدخال عدد الدقائق أولاً", MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading, "المبرمج مهند")
            TextBox1.Focus()
        Else
            RunCMD("R")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RunCMD("A")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button5.Click, PictureBox1.DoubleClick
        Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = Me.Icon.ToBitmap

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextBox1.Visible = RadioButton1.Checked
        DateTimePicker1.Visible = RadioButton2.Checked

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TextBox1.Visible = RadioButton1.Checked
        DateTimePicker1.Visible = RadioButton2.Checked

    End Sub

    Private Sub RunCMD(Type As Char)
        Try
            If (RadioButton1.Checked) Then
                sec = Val(TextBox1.Text) * 60
            Else
                Dim hh As Integer = Hour(DateTimePicker1.Value) - Hour(Now)
                Dim mm As Integer = Minute(DateTimePicker1.Value) - Minute(Now)
                Dim ss As Integer = Second(DateTimePicker1.Value) - Second(Now)

                sec = (hh * 3600) + (mm * 60) + (ss)
            End If
            Dim ms As String = ""
            If (Type = "S") Then
                If (RadioButton1.Checked And Val(TextBox1.Text) = 0) Then
                    If (MsgBox("هل تريد إيقاف التشغيل مباشرةً", MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "المبرمج مهند") = MsgBoxResult.No) Then Return
                End If
                Shell("shutdown -s -t " + sec.ToString())
                ms = ms + "سيتم إيقاف تشغيل الكمبيوتر  "
                If (RadioButton1.Checked) Then ms = ms + vbNewLine + " بعد " + TextBox1.Text + " دقيقة " Else ms = ms + vbNewLine + " بتوقيت " + DateTimePicker1.Text
            ElseIf (Type = "R") Then
                If (RadioButton1.Checked And Val(TextBox1.Text) = 0) Then
                    If (MsgBox("هل تريد إعادة التشغيل مباشرةً", MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "المبرمج مهند") = MsgBoxResult.No) Then Return
                End If
                Shell("shutdown -r -t " + sec.ToString())
                ms = ms + "سيتم إعادة تشغيل الكمبيوتر  "
                If (RadioButton1.Checked) Then ms = ms + vbNewLine + " بعد " + TextBox1.Text + " دقيقة " Else ms = ms + vbNewLine + " بتوقيت " + DateTimePicker1.Text
            Else
                Shell("shutdown -a")
                ms = ms + "تم إلغاء إيقاف أو إعادة تشغيل الكمبيوتر  "
            End If
            MsgBox(ms, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading, "المبرمج مهند")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading, "المبرمج مهند")
        End Try
    End Sub
End Class
