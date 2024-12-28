pipeline {
    agent any
    environment {
        PATH = "/usr/local/share/dotnet:$PATH"  // Assurez-vous que le chemin vers dotnet est inclus
    }
    stages {
        stage('Check Dotnet Version') {
            steps {
                script {
                    // Vérifie la version de dotnet
                    sh 'dotnet --version'
                }
            }
        }
        stage('Restore Dependencies') {
            steps {
                script {
                    // Restaure les dépendances du projet
                    sh 'dotnet restore'
                }
            }
        }
        stage('Build Project') {
            steps {
                script {
                    // Compile le projet
                    sh 'dotnet build --configuration Release'
                }
            }
        }
        stage('Run Tests') {
            steps {
                script {
                    // Exécute les tests unitaires
                    sh 'dotnet test --configuration Release'
                }
            }
        }
    }
}
