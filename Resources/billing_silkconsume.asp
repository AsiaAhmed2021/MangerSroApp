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
Dim Silk_Offset_Own
Dim Silk_Offset_Gift
Dim Mileage_Offset
Dim ShardID
Dim CharID
Dim ItemID
Dim IP
Dim Valid_Key

UserJID = Trim(Request("JID"))
Silk_Offset_Own = Trim(Request("so"))
Silk_Offset_Gift = Trim(Request("sg"))
Mileage_Offset = Trim(Request("sp"))
ShardID = Trim(Request("sid"))
CharID = Trim(Request("cid"))
ItemID = Trim(Request("iid"))
IP = Trim(Request("ip"))
Valid_Key = Trim(Request("vk"))

UserJID = FilterReqXSS(UserJID)
Silk_Offset_Own = FilterReqXSS(Silk_Offset_Own)
Silk_Offset_Gift = FilterReqXSS(Silk_Offset_Gift)
Mileage_Offset = FilterReqXSS(Mileage_Offset)
ShardID = FilterReqXSS(ShardID)
CharID = FilterReqXSS(CharID)
ItemID = FilterReqXSS(ItemID)
IP = FilterReqXSS(IP)
Valid_Key = FilterReqXSS(Valid_Key)


' Error - Parameter
Dim ParaResult

ParaResult = 1

If Valid_Key = "" OR IsNull(Valid_Key) OR IsEmpty(Valid_Key) Then
	ParaResult = -10
End If
If IP = "" OR IsNull(IP) OR IsEmpty(IP) Then
	ParaResult = -9
End If
If ItemID = "" OR IsNull(ItemID) OR IsEmpty(ItemID) Then
	ParaResult = -8
End If
If CharID = "" OR IsNull(CharID) OR IsEmpty(CharID) Then
	ParaResult = -7
End If
If ShardID = "" OR IsNull(ShardID) OR IsEmpty(ShardID) Then
	ParaResult = -6
End If
If Mileage_Offset = "" OR IsNull(Mileage_Offset) OR IsEmpty(Mileage_Offset) Then
	ParaResult = -5
End If
If Silk_Offset_Gift = "" OR IsNull(Silk_Offset_Gift) OR IsEmpty(Silk_Offset_Gift) Then
	ParaResult = -4
End If
If Silk_Offset_Own = "" OR IsNull(Silk_Offset_Own) OR IsEmpty(Silk_Offset_Own) Then
	ParaResult = -3
End If
If UserJID = "" OR IsNull(UserJID) OR IsEmpty(UserJID) Then
	ParaResult = -2
End If

If ParaResult <> 1 Then
	DBConnA.Close
	Set DBConnA = Nothing

	Response.Write ParaResult
	Response.End
End If



''''''''''
Dim KeyString
Dim objMD5
Dim Confirm_Valid_Key

KeyString = "SROG8Z_CDE1210598DK_AKD3HW1K04DL2-"

Set objMD5 = New MD5
objMD5.Text = UserJID & "." & Silk_Offset_Own & "." & Silk_Offset_Gift & "." & Mileage_Offset & "." & ShardID & "." & CharID & "." & ItemID & "." & IP & "." & KeyString
Confirm_Valid_Key = objMD5.HEXMD5

' Error
If Err.Number <> 0 Then
	DBConnA.Close
	Set DBConnA = Nothing

	Response.Write "-11"
	Response.End
End If

If Trim(Valid_Key) <> Trim(Confirm_Valid_Key) Then
	DBConnA.Close
	Set DBConnA = Nothing

	Response.Write "-12"
	Response.End
End If



''''''''''
Dim sdSQL
Dim sdRS
Dim ReturnValue

sdSQL = "DEClARE @ReturnValue int "
sdSQL = sdSQL & "DECLARE @Silk_Offset_Own int "
sdSQL = sdSQL & "DEClARE @Silk_Offset_Gift int "
sdSQL = sdSQL & "DECLARE @Mileage_Offset int "
sdSQL = sdSQL & "DECLARE @ShardID int "
sdSQL = sdSQL & "DECLARE @CharID int "
sdSQL = sdSQL & "DECLARE @ItemID int "
sdSQL = sdSQL & "DECLARE @IP int "
sdSQL = sdSQL & "SET @Silk_Offset_Own = "& Silk_Offset_Own &" "
sdSQL = sdSQL & "SET @Silk_Offset_Gift = "& Silk_Offset_Gift &" "
sdSQL = sdSQL & "SET @Mileage_Offset = "& Mileage_Offset &" "
sdSQL = sdSQL & "SET @ShardID = "& ShardID &" "
sdSQL = sdSQL & "SET @CharID = "& CharID &" "
sdSQL = sdSQL & "SET @ItemID = "& ItemID &" "
sdSQL = sdSQL & "SET @IP = "& IP &" "
sdSQL = sdSQL & "EXEC @ReturnValue = _ConsumeSilkByGameServer2 "& UserJID &", @Silk_Offset_Own OUTPUT, @Silk_Offset_Gift OUTPUT, @Mileage_Offset OUTPUT, @ShardID, @CharID, @ItemID, @IP "
sdSQL = sdSQL & "SELECT @ReturnValue, @Silk_Offset_Own, @Silk_Offset_Gift, @Mileage_Offset "
Set sdRS = DBConnA.Execute(sdSQL)

ReturnValue = sdRS(0)
Silk_Offset_Own = sdRS(1)
Silk_Offset_Gift = sdRS(2)
Mileage_Offset = sdRS(3)

sdRS.Close
Set sdRS = Nothing
DBConnA.Close
Set DBConnA = Nothing

' Error
If Err.Number <> 0 Then
	Response.Write "-13"
	Response.End
End If



' return
If Cint(ReturnValue) = 1 Then
	Response.Write "1:"& Silk_Offset_Own &","& Silk_Offset_Gift &","& Mileage_Offset
Else
	Response.Write "-14:"& ReturnValue
End If
Response.End
%>