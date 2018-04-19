Imports CSLibs.Cs

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnTest As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnTest = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(72, 56)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.TabIndex = 0
        Me.btnTest.Text = "&Test"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(216, 149)
        Me.Controls.Add(Me.btnTest)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        Dim mylib As CSLibs.Cs = New CSLibs.Cs
        Dim result As Integer = mylib.Add(5, 3)
        MessageBox.Show(result.ToString())

        Dim myVB As VBLib = New VBLib
        MessageBox.Show(myVB.Name)
    End Sub

End Class

Public Class VBLib
    Inherits CSLibs.Cs

    Public Sub New()
        MyBase.New("VB")
    End Sub

    Public Sub New(ByVal name As String)
        MyBase.New(name)
    End Sub
End Class