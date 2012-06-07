<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
		Me.txtSearch = New System.Windows.Forms.TextBox()
		Me.btnSearch = New System.Windows.Forms.Button()
		Me.lvItems = New System.Windows.Forms.ListView()
		Me.chName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.chPrice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.chChange = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.chMembers = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.chID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.SuspendLayout()
		'
		'txtSearch
		'
		Me.txtSearch.BackColor = System.Drawing.Color.WhiteSmoke
		Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtSearch.Location = New System.Drawing.Point(13, 12)
		Me.txtSearch.Name = "txtSearch"
		Me.txtSearch.Size = New System.Drawing.Size(305, 20)
		Me.txtSearch.TabIndex = 0
		'
		'btnSearch
		'
		Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
		Me.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lavender
		Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender
		Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSearch.Location = New System.Drawing.Point(325, 12)
		Me.btnSearch.Name = "btnSearch"
		Me.btnSearch.Size = New System.Drawing.Size(144, 35)
		Me.btnSearch.TabIndex = 1
		Me.btnSearch.Text = "Search G.E."
		Me.btnSearch.UseVisualStyleBackColor = True
		'
		'lvItems
		'
		Me.lvItems.BackColor = System.Drawing.Color.WhiteSmoke
		Me.lvItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lvItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chName, Me.chPrice, Me.chChange, Me.chMembers, Me.chID})
		Me.lvItems.FullRowSelect = True
		Me.lvItems.GridLines = True
		Me.lvItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
		Me.lvItems.HideSelection = False
		Me.lvItems.Location = New System.Drawing.Point(13, 53)
		Me.lvItems.MultiSelect = False
		Me.lvItems.Name = "lvItems"
		Me.lvItems.Size = New System.Drawing.Size(456, 299)
		Me.lvItems.TabIndex = 2
		Me.lvItems.UseCompatibleStateImageBehavior = False
		Me.lvItems.View = System.Windows.Forms.View.Details
		'
		'chName
		'
		Me.chName.Text = "Name"
		Me.chName.Width = 115
		'
		'chPrice
		'
		Me.chPrice.Text = "Price"
		Me.chPrice.Width = 80
		'
		'chChange
		'
		Me.chChange.Text = "Today's Change (gp)"
		Me.chChange.Width = 120
		'
		'chMembers
		'
		Me.chMembers.Text = "Members"
		Me.chMembers.Width = 73
		'
		'chID
		'
		Me.chID.Text = "ID"
		Me.chID.Width = 63
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.WhiteSmoke
		Me.ClientSize = New System.Drawing.Size(481, 365)
		Me.Controls.Add(Me.lvItems)
		Me.Controls.Add(Me.btnSearch)
		Me.Controls.Add(Me.txtSearch)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "Form1"
		Me.Text = "Grand Exchange Parser"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents txtSearch As System.Windows.Forms.TextBox
	Friend WithEvents btnSearch As System.Windows.Forms.Button
	Friend WithEvents lvItems As System.Windows.Forms.ListView
	Friend WithEvents chName As System.Windows.Forms.ColumnHeader
	Friend WithEvents chPrice As System.Windows.Forms.ColumnHeader
	Friend WithEvents chChange As System.Windows.Forms.ColumnHeader
	Friend WithEvents chMembers As System.Windows.Forms.ColumnHeader
	Friend WithEvents chID As System.Windows.Forms.ColumnHeader

End Class
