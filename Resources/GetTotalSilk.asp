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

'''''''''' Check ACL only Call from Billing Server
Dim IP
Dim BillingServer
BillingServer = "88.38.123.110"
IP = Request.ServerVariables("REMOTE_ADDR")
'If(IP <> BillingServer) Then
'	Response.Write "ACCESSDENY"
'	Response.End
'End If
''''''''''
Dim sdSQL
Dim sdRS
Dim ReturnValue

sdSQL = "SET NOCOUNT ON  EXEC CGI.CGI_WebGetTotalSilk "
'Response.Write sdSQL
'Response.End

Set sdRS = DBConnA.Execute(sdSQL)
ReturnValue = sdRS(0)

sdRS.Close
Set sdRS = Nothing
DBConnA.Close
Set DBConnA = Nothing

' Error
If Err.Number <> 0 Then
	Response.Write "-1"
	Response.End
End If
Response.Write ReturnValue
Response.End
%>

