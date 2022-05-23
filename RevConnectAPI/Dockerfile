# The dockerfile is the script or the commands that are followed to build a docker image.
# The FROM statement/command pulls an image to start working off of.
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# FROM <repo>/<user>/<image>:<tag>(tag specifies the version of a particular image, defaults to "latest")
# AS lets us set an alias for the building environment.

# The WORKDIR statement/command changes the working directory of the container.
# Creating a folder called "App" inside the container
WORKDIR /App
# If the specifies directory does not exit in the container, it will be created.

# The COPY statment/command copies files the host to the container.
COPY ./ ./
# COPY <source/the file location of the docker file> <destination/inside the working direction of the container/image>

# The RUN statement/command runs a command inside the container (all the container is to build this application for us)

# RUN <command>

RUN dotnet publish -c Release


# 2nd phase builds - start by building the solution, then pare down the environment to the minimum needed 
# to run the executable.
# The SDK is too LARGE package to include, and is only really necessary for the first build.
# Running the project can be done with a more limited environment.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS run

WORKDIR /App

COPY  --from=build /App/RevConnectAPI/bin/Release/net6.0/publish  ./



# The ENTRYPOINT statement/command specifies the command that is run when the container is started.
# (The ENTRYPOINT statement/command tells our image when this container starts)


ENTRYPOINT ["dotnet", "./RevConnectAPI.dll"]