Imports System.Net
Imports System.Threading

Public Class Form1

	Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Me.UpdateStatus("Form loaded")
	End Sub

	Private Function isMembers(ByVal s As String) As Boolean
		If s.Contains("Member") Then
			Return True
		End If

		Return False
	End Function

	Private Sub ParseData()
		Dim ID As String, Name As String, Price As String, Change As String, Members As String
		Dim CurrentPage As Integer = 0, PageCount As Integer = &HFFFF, ItemCount As Integer = 0

		Me.UpdateStatus("Working...")
		Me.lvItems.BeginUpdate()

		While CurrentPage < PageCount
			Try
				Dim task As New TaskClass()
				Dim thread1 As New Threading.Thread(AddressOf task.GetPageData)

				task.argStr = Me.txtSearch.Text
				task.argInt = CurrentPage

				thread1.Start()
				thread1.Join()

				Dim Source As String = task.retValStr
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
					Members = Convert.ToString(isMembers(ItemArray(i).Split(New String() {"title="""}, StringSplitOptions.None)(1).Split(New String() {""">"}, StringSplitOptions.None)(0)))

					Me.UpdateListView(ID, Name, Price, Change, Members)

					ItemCount += 1
				Next

				CurrentPage += 1
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error!")
				Exit Sub
			End Try
		End While

		Me.UpdateStatus("Found " & ItemCount.ToString() & " item(s) across " & PageCount.ToString() & " page(s)")
		Me.lvItems.EndUpdate()
	End Sub

	Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
		Dim thread1 As New Threading.Thread(AddressOf Me.ParseData)

		Me.lvItems.Items.Clear()
		thread1.Start()
	End Sub

	Public Delegate Sub DelegateUpdateStatus(ByVal s As String)
	Private Sub UpdateStatus(ByVal s As String)
		If Me.InvokeRequired Then
			Dim d As New DelegateUpdateStatus(AddressOf UpdateStatus)
			Me.Invoke(d, New Object() {s})
		Else
			Me.Text = "Status: " & s
		End If
	End Sub

	Public Delegate Sub DelegateUpdateListView(ByVal ID As String, ByVal Name As String, ByVal Price As String, ByVal Change As String, ByVal Members As String)
	Private Sub UpdateListView(ByVal ID As String, ByVal Name As String, ByVal Price As String, ByVal Change As String, ByVal Members As String)
		If Me.InvokeRequired Then
			Dim d As New DelegateUpdateListView(AddressOf UpdateListView)
			Me.Invoke(d, New Object() {ID, Name, Price, Change, Members})
		Else
			Me.lvItems.Items.Add(Name)
			Me.lvItems.Items(lvItems.Items.Count - 1).SubItems.Add(Price)
			Me.lvItems.Items(lvItems.Items.Count - 1).SubItems.Add(Change)
			Me.lvItems.Items(lvItems.Items.Count - 1).SubItems.Add(Members)
			Me.lvItems.Items(lvItems.Items.Count - 1).SubItems.Add(ID)

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
		End If
	End Sub
End Class

Class TaskClass
	Friend argInt As Integer
	Friend argStr As String
	Friend retValStr As String

	Sub GetPageData()
		Dim client As New WebClient()

		client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.6 (KHTML, like Gecko) Chrome/20.0.1092.0 Safari/536.6")
		Me.retValStr = client.DownloadString(("http://services.runescape.com/m=itemdb_rs/results.ws?page=" & (Me.argInt + 1).ToString() & "&query=") + Me.argStr & "&price=all&members=")

		client.Dispose()
	End Sub
End Class