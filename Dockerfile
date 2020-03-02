FROM mcr.microsoft.com/dotnet/core/sdk:2.2 
COPY . /app
WORKDIR /app
RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl git nano	
RUN curl -sL https://deb.nodesource.com/setup_8.x | bash - && apt-get install -yq nodejs build-essential	
RUN npm install -g npm	
RUN npm install -g @angular/cli 
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 80
EXPOSE 5001
EXPOSE 5000
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh