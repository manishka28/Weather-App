pipeline {
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/sdk:8.0'
            args '-u root'
        }
    }

    environment {
        SONAR_TOKEN = credentials('sonar-token')
    }

    stages {

        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --no-restore'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test --no-build'
            }
        }

        stage('SonarQube Analysis') {
            steps {
                withSonarQubeEnv('SonarQube') {
                    sh """
                    dotnet tool install --global dotnet-sonarscanner
                    export PATH="$PATH:/root/.dotnet/tools"

                    dotnet sonarscanner begin \
                    /k:"WeatherApp" \
                    /d:sonar.host.url="http://host.docker.internal:9000" \
                    /d:sonar.login="${SONAR_TOKEN}"

                    dotnet build

                    dotnet sonarscanner end \
                    /d:sonar.login="${SONAR_TOKEN}"
                    """
                }
            }
        }

        stage('Publish') {
            steps {
                sh 'dotnet publish -c Release -o publish'
            }
        }
    }
}