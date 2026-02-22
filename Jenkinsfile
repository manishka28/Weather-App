pipeline {
    agent any

    environment {
        SONAR_HOST = "http://host.docker.internal:9000"
        SONAR_TOKEN = credentials('sonar-token')
    }

    stages {

        stage('Checkout') {
            steps {
                git 'https://github.com/manishka28/Weather-App.git'
            }
        }

        stage('Backend Build + Sonar') {
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/sdk:10.0'
        }
    }
    steps {
        sh """
        dotnet --version

        dotnet tool install --global dotnet-sonarscanner
        export PATH="\$PATH:/root/.dotnet/tools"

        dotnet sonarscanner begin \
          /k:"WeatherApp-Backend" \
          /d:sonar.host.url="${SONAR_HOST}" \
          /d:sonar.login="${SONAR_TOKEN}"

        dotnet build server/src/WeatherApp.Api

        dotnet sonarscanner end \
          /d:sonar.login="${SONAR_TOKEN}"
        """
    }
}

        stage('Frontend Build + Sonar') {
            agent {
                docker {
                    image 'node:20'
                }
            }
            steps {
                sh """
                cd frontend/weather-app
                npm install
                npm run build

                npx sonar-scanner \
                  -Dsonar.projectKey=WeatherApp-Frontend \
                  -Dsonar.host.url=${SONAR_HOST} \
                  -Dsonar.login=${SONAR_TOKEN}
                """
            }
        }
    }
}