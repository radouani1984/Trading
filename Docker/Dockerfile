FROM mcr.microsoft.com/mssql/server
ENV ACCEPT_EULA=Y
ENV ACCEPT_EULA=Y
ENV MSSQL_SA_PASSWORD=Mama21911301..
EXPOSE 1433

CMD ["/bin/sh","-c", "while true; do sleep 30; done;"]


# docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Mama21911301.." \
#     -p 1433:1433 --name sql1 -h sql1 \
#     -d mcr.microsoft.com/mssql/server

# /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Mama21911301.."