pipeline {
    agent any
    environment {
        PATH = "/usr/local/share/dotnet:$PATH"  // Assurez-vous que le chemin vers dotnet est inclus
    }
    stages {
        stage('Check Dotnet Version') {
            steps {
                script {
                    sh 'dotnet --version'
                }
            }
        }
    }
}
