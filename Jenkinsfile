pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                // Récupère le code source depuis le dépôt Git
                checkout scm
            }
        }
        stage('Restore') {
            steps {
                // Restaure les dépendances du projet
                sh 'dotnet restore'
            }
        }
        stage('Build') {
            steps {
                // Compile le projet
                sh 'dotnet build --configuration Release'
            }
        }
        stage('Test') {
            steps {
                // Exécute les tests unitaires et génère un rapport XML avec xUnit
                sh 'dotnet test --configuration Release --logger:xunit;LogFileName=TestResults/testresult.xml'
            }
            post {
                always {
                    // Publie les résultats des tests avec xUnit
                    xunit(
                        testResults: 'TestResults/testresult.xml',
                        testTimeMargin: '3000', 
                        thresholdMode: 1
                    )
                }
            }
        }
        stage('Publish') {
            steps {
                // Publie l'application
                sh 'dotnet publish --configuration Release --output publish'
            }
        }
    }
}
