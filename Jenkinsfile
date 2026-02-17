pipeline {
    agent any

    stages {

        stage('Stop Old Containers') {
            steps {
                sh 'docker stop weather-backend || true'
                sh 'docker stop weather-frontend || true'
                sh 'docker rm weather-backend || true'
                sh 'docker rm weather-frontend || true'
            }
        }

        stage('Build Images') {
            steps {
                sh 'docker build -t weather-backend ./backend'
                sh 'docker build -t weather-frontend ./frontend'
            }
        }

        stage('Run Containers') {
            steps {
                sh 'docker run -d -p 5000:80 --name weather-backend weather-backend'
                sh 'docker run -d -p 4200:80 --name weather-frontend weather-frontend'
            }
        }
    }
}