<%
Dim DBConnA, strConnectA
Set DBConnA = Server.CreateObject("ADODB.Connection")
strConnectA = "Provider=SQLOLEDB;Data Source=[Host];Initial Catalog=[VsroAccount];user ID=[User];password=[PassWorld];"
DBConnA.Open strConnectA

%>