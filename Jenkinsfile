pipeline {
    agent any

    stages {

        stage('Clone') {
            steps {
                git 'https://github.com/manishka28/Weather-App.git'
            }
        }

        stage('Build & Deploy') {
            steps {
                bat 'docker-compose down'
                bat 'docker-compose up --build -d'
            }
        }
    }
}