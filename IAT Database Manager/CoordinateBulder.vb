Imports System.IO

Public Class CoordinateBulder
    Private Sub txtInput_TextChanged(sender As Object, e As EventArgs) Handles txtInput.TextChanged
        txtOutput.Text = ""
        Dim criteriaID As String
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("achievement.csv")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim StrArr As String()
            While Not MyReader.EndOfData
                Try
                    StrArr = MyReader.ReadFields()
                    If StrArr(3) = txtAchievementID.Text Then
                        criteriaID = StrArr(14)
                    End If
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    Console.WriteLine("Line " & ex.Message & "is not valid and will be skipped.")
                End Try
            End While
        End Using
        txtOutput.AppendText("function core._" & txtAreaID.Text & ":" & vbNewLine)
        Dim Lines As String() = txtInput.Text.Split(vbNewLine)
        For Each line As String In txtInput.Lines
            Dim strArr() As String = line.Split(" ")
            Dim x = strArr(1)
            Dim y = strArr(2)
            Dim area As String
            Dim criteriaIndex As Integer = 99999
            For i = 3 To strArr.Count() - 1
                area += strArr(i) & " "
            Next
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("criteriatree.csv")
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(",")
                While Not MyReader.EndOfData
                    Try
                        strArr = MyReader.ReadFields()
                        If strArr(2) = criteriaID Then
                            If area.ToLower.Trim() = strArr(1).ToLower.Trim() Then
                                criteriaIndex = strArr(6) + 1
                            End If
                        End If
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        Console.WriteLine("Line " & ex.Message & "is not valid and will be skipped.")
                    End Try
                End While
            End Using
            txtOutput.AppendText(vbTab & "core:InsertWaypoint(" & x & ", " & y & ", 1, " & txtAchievementID.Text & ", " & criteriaIndex & ") --" & area & vbNewLine)
            area = ""
        Next
        txtOutput.AppendText("end")
    End Sub
End Class