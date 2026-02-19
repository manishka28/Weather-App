pipeline {
    agent any

    stages {

        stage('Restore') {
            steps {
                sh 'dotnet restore backend/WeatherApi/WeatherApi.csproj'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build backend/WeatherApi/WeatherApi.csproj --no-restore'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test backend/WeatherApi/WeatherApi.csproj --no-build'
            }
        }

        stage('Publish') {
            steps {
                sh 'dotnet publish backend/WeatherApi/WeatherApi.csproj -c Release -o publish'
            }
        }
    }
}