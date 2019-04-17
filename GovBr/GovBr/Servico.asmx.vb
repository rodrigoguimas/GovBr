Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

' Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class Servico
    Inherits System.Web.Services.WebService

    <WebMethod>
    Public Function UploadArquivo(ByVal nomeDoArquivo As String, ByVal arquivoByte As Byte()) As String
        Try
            Dim arquivo As String = Server.MapPath("~/Arquivos/") & nomeDoArquivo
            System.IO.File.WriteAllBytes(arquivo, arquivoByte)
        Catch ex As Exception
            Return "Erro ao realizar o Upload! (" & ex.Message & ")"
        End Try

        Return "Upload realizado com sucesso!"
    End Function

    <WebMethod>
    Public Function DownloadArquivo(ByVal nomeDoArquivo As String) As Byte()
        Dim arquivo As String = Server.MapPath("~/Arquivos/") & nomeDoArquivo
        Dim fileStream As System.IO.FileStream = System.IO.File.Open(arquivo, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Dim arquivoByte As Byte() = New Byte(fileStream.Length - 1) {}
        fileStream.Read(arquivoByte, 0, Convert.ToInt32(fileStream.Length))
        fileStream.Close()
        Return arquivoByte
    End Function
End Class

