<!-- #include file = "DBConnect.asp" -->
<!-- #include file = "Function.asp" -->
<!-- #include file = "Class_MD5.asp" -->

<%
On Error Resume Next

' Error
If Err.Number <> 0 Then
	Response.Write "-1"
	Response.End
End If



'''''''''' Req
Dim UserJID

UserJID = Trim(Request("JID"))

UserJID = FilterReqXSS(UserJID)


' Error
If UserJID = "" OR IsNull(UserJID) OR IsEmpty(UserJID) Then
	DBConnA.Close
	Set DBConnA = Nothing

	Response.Write "-2"
	Response.End
End If



''''''''''
Dim sdSQL
Dim sdRS
Dim ReturnValue
Dim SilkOwn
Dim SilkGift
Dim Mileage

sdSQL = "DECLARE @ReturnValue int "
sdSQL = sdSQL & "DECLARE @SilkOwn int "
sdSQL = sdSQL & "DECLARE @SilkGift int "
sdSQL = sdSQL & "DECLARE @Mileage int "
sdSQL = sdSQL & "EXEC @ReturnValue = _GetSilkDataForGameServer "& UserJID &", @SilkOwn OUTPUT, @SilkGift OUTPUT, @Mileage OUTPUT "
sdSQL = sdSQL & "SELECT @ReturnValue, @SilkOwn, @SilkGift, @Mileage"
Set sdRS = DBConnA.Execute(sdSQL)

ReturnValue = sdRS(0)
SilkOwn = sdRS(1)
SilkGift = sdRS(2)
Mileage = sdRS(3)

sdRS.Close
Set sdRS = Nothing
DBConnA.Close
Set DBConnA = Nothing

' Error
If Err.Number <> 0 Then
	Response.Write "-3"
	Response.End
End If

' return
If Cint(ReturnValue) <> 0 Then
	Response.Write "-4"
	Response.End
Else
	If SilkOwn = "" OR IsNull(SilkOwn) OR IsEmpty(SilkOwn) Then SilkOwn = 0
	If SilkGift = "" OR IsNull(SilkGift) OR IsEmpty(SilkGift) Then SilkGift = 0
	If Mileage = "" OR IsNull(Mileage) OR IsEmpty(Mileage) Then Mileage = 0
End If



''''''''''
Dim KeyString
Dim objMD5
Dim Valid_Key

KeyString = "SROG8Z_CDE1210598DK_AKD3HW1K04DL2-"

Set objMD5 = New MD5
objMD5.Text = UserJID & "." & SilkOwn & "." & SilkGift & "." & Mileage & "." & KeyString
Valid_Key = objMD5.HEXMD5

' Error
If Err.Number <> 0 Then
	Response.Write "-5"
	Response.End
End If



''''''''''
Response.Write "1:"& SilkOwn &","& SilkGift &","& Mileage &","& Valid_Key
Response.End
%>