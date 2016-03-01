#FROM microsoft/aspnet:1.0.0-rc1-update1
#
#COPY ./WebApp/project.json /app/WebApp/
#COPY ./NuGet.Config /app/
#COPY ./global.json /app/
#WORKDIR /app/WebApp
#RUN ["dnu", "restore"]
#ADD ./WebApp /app/WebApp/
#
#EXPOSE 5090
#ENTRYPOINT ["dnx", "run"]

FROM microsoft/aspnet:1.0.0-rc1-update1

#intall nodejs & npm
RUN apt-get update
RUN apt-get -y install nodejs
RUN apt-get install nodejs-legacy
RUN apt-get -y install npm
RUN apt-get -y install git
RUN npm -g install npm@latest
RUN npm cache clean -f
RUN npm install -g n
RUN n stable
RUN npm install -g bower
RUN npm install -g gulp
RUN echo '{ "allow_root": true }' > /root/.bowerrc



COPY ./src/Singl/ /app
WORKDIR /app
RUN ["dnu", "restore"]
RUN ["gulp", "optimize-images"]

EXPOSE 5004/tcp
ENTRYPOINT ["dnx", "kestrel"]
