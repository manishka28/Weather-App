pipeline {
    agent any

    environment {
        SONAR_TOKEN = credentials('sonar-token')
    }

    stages {

        

        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --no-restore'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test --no-build'
            }
        }

        stage('SonarQube Analysis') {
            steps {
                withSonarQubeEnv('SonarQube') {
                    bat """
                    dotnet sonarscanner begin ^
                    /k:"WeatherApp" ^
                    /d:sonar.host.url="http://localhost:9000" ^
                    /d:sonar.login="%SONAR_TOKEN%"

                    dotnet build

                    dotnet sonarscanner end ^
                    /d:sonar.login="%SONAR_TOKEN%"
                    """
                }
            }
        }

        stage('Publish') {
            steps {
                bat 'dotnet publish -c Release -o publish'
            }
        }
    }
}