<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InsertExpansion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtExpansionName = New System.Windows.Forms.TextBox()
        Me.txtExpansionID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAddExpansion = New System.Windows.Forms.Button()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtExpansionName
        '
        Me.txtExpansionName.Location = New System.Drawing.Point(46, 11)
        Me.txtExpansionName.Name = "txtExpansionName"
        Me.txtExpansionName.Size = New System.Drawing.Size(214, 20)
        Me.txtExpansionName.TabIndex = 0
        '
        'txtExpansionID
        '
        Me.txtExpansionID.Location = New System.Drawing.Point(46, 37)
        Me.txtExpansionID.Name = "txtExpansionID"
        Me.txtExpansionID.Size = New System.Drawing.Size(214, 20)
        Me.txtExpansionID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "ID"
        '
        'btnAddExpansion
        '
        Me.btnAddExpansion.Location = New System.Drawing.Point(7, 68)
        Me.btnAddExpansion.Name = "btnAddExpansion"
        Me.btnAddExpansion.Size = New System.Drawing.Size(252, 37)
        Me.btnAddExpansion.TabIndex = 4
        Me.btnAddExpansion.Text = "Add Expansion"
        Me.btnAddExpansion.UseVisualStyleBackColor = True
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(7, 111)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(252, 20)
        Me.txtStatus.TabIndex = 5
        '
        'InsertExpansion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 136)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.btnAddExpansion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtExpansionID)
        Me.Controls.Add(Me.txtExpansionName)
        Me.Name = "InsertExpansion"
        Me.Text = "InsertExpansion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtExpansionName As TextBox
    Friend WithEvents txtExpansionID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAddExpansion As Button
    Friend WithEvents txtStatus As TextBox
End Class
