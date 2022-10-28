Imports System.Text

Public Class Form1
    Dim stringBuilder As StringBuilder 
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim Par As New Parameters
        Par.GeneratedNumber=200
        Par.Multiplier=16807
        Par.Increment=0
        Par.Seed=3793

        stringBuilder = RNG(par)

        TextBox1.Text=stringBuilder.ToString()

    End Sub

  
    Public  Shared Function RNG(ByVal P As Parameters) As StringBuilder
        Dim d As Double = (Math.pow(2, 31) - 1)
        Dim tempSeed As Double =P.Seed   
        Dim output As Double 
        Dim GeneratedNumber As Integer =P.GeneratedNumber  
        Dim temp1 As Double 
        dim st as New StringBuilder
        While (GeneratedNumber > 0)
            temp1 = ((P.Multiplier * tempSeed) + P.Increment)  Mod d 
            output = temp1 / d
            st.AppendLine(output.ToString().Trim())
            tempSeed = temp1
            GeneratedNumber -= 1
        End While
       Return st
    End Function
 

    class Parameters
       public property GeneratedNumber As  Integer
       public property Multiplier As Double	  
       public property Increment As Double   
       public property Seed As Double	 
    End Class

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"
        SaveFileDialog1.FileName="Results-RNG-Using-VisualBasicNET"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
            Then
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text.Trim(), False, System.Text.Encoding.    Default)
        End If
    End Sub


End Class


