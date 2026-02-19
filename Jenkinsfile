pipeline {
    agent any

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
                    dotnet sonarscanner begin \
                    /k:"WeatherApp" \
                    /d:sonar.host.url="http://localhost:9000" \
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