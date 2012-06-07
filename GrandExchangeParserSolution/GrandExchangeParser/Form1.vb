Imports System.Net

Public Class Form1

	Private Sub UpdateStatus(ByVal s As String)
		Me.Text = "Status: " & s
	End Sub

	Private Function isMembers(ByVal s As String) As Boolean
		If s.Contains("Member") Then
			Return True
		End If

		Return False
	End Function

	Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
		Dim ID As String, Name As String, Price As String, Change As String, Members As String
		Dim client As New WebClient()
		Dim CurrentPage As Integer = 0, PageCount As Integer = &HFFFF, ItemCount As Integer = 0

		client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")

		Me.lvItems.Items.Clear()
		Me.lvItems.BeginUpdate()

		Me.UpdateStatus("Working...")

		While CurrentPage < PageCount
			Try
				Dim Source As String = client.DownloadString(("http://services.runescape.com/m=itemdb_rs/results.ws?page=" & (CurrentPage + 1).ToString() & "&query=") + Me.txtSearch.Text & "&price=all&members=")
				Dim ItemArray As String() = Source.Split(New String() {"<tr data-item-id="""}, StringSplitOptions.None)

				If PageCount = &HFFFF Then
					PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Source.Split(New String() {"<em>"}, StringSplitOptions.None)(2).Split(New String() {"</em>"}, StringSplitOptions.None)(0)) / 20))
				End If

				Me.UpdateStatus("Downloading page " & (CurrentPage + 1).ToString() & " of " & PageCount.ToString())

				For i As Integer = 1 To ItemArray.Length - 1
					ID = ItemArray(i).Split(New String() {""">"}, StringSplitOptions.None)(0)
					Name = ItemArray(i).Split(New String() {"alt="""}, StringSplitOptions.None)(1).Split(""""c)(0)
					Price = ItemArray(i).Split(New String() {"<td class=""price"">"}, StringSplitOptions.None)(1).Split(New String() {"</td>"}, StringSplitOptions.None)(0)
					Change = ItemArray(i).Split(New String() {"<td class=""neutral"">", "<td class=""positive"">", "<td class=""negative"">"}, StringSplitOptions.None)(1).Split(New String() {"</td>"}, StringSplitOptions.None)(0)
					Members = ItemArray(i).Split(New String() {"title="""}, StringSplitOptions.None)(1).Split(New String() {""">"}, StringSplitOptions.None)(0)

					Members = Convert.ToString(isMembers(Members))

					Me.lvItems.Items.Add(Name)
					Me.lvItems.Items(lvItems.Items.Count - 1).SubItems.Add(Price)
					Me.lvItems.Items(lvItems.Items.Count - 1).SubItems.Add(Change)
					Me.lvItems.Items(lvItems.Items.Count - 1).SubItems.Add(Members)
					Me.lvItems.Items(lvItems.Items.Count - 1).SubItems.Add(ID)

					ItemCount += 1
				Next

				CurrentPage += 1
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error!")
				Exit Sub
			End Try
		End While

		For I As Integer = 0 To Me.lvItems.Items.Count - 1
			Me.lvItems.Items(I).UseItemStyleForSubItems = False

			If I Mod 2 = 0 Then
				Me.lvItems.Items(I).BackColor = Color.Lavender

				For II As Integer = 1 To 4
					Me.lvItems.Items(I).SubItems(II).BackColor = Color.Lavender
				Next
			End If

			If Me.lvItems.Items(I).SubItems(2).Text.Contains("-") Then
				Me.lvItems.Items(I).SubItems(2).ForeColor = Color.Red
			ElseIf Me.lvItems.Items(I).SubItems(2).Text.Contains("+") Then
				Me.lvItems.Items(I).SubItems(2).ForeColor = Color.Green
			End If
		Next

		Me.lvItems.EndUpdate()
		Me.UpdateStatus("Found " & ItemCount.ToString() & " item(s) across " & PageCount.ToString() & " page(s)")
	End Sub

	Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Me.UpdateStatus("Form loaded")
	End Sub
End Class
