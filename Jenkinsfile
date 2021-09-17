pipeline {
    agent any
    options {
        skipStagesAfterUnstable()
    }
    stages {
        stage('Build') {
            steps {
                echo 'Building g'
            }
        }
        stage('Test') {
            steps {
                echo 'Testing g'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying g'
            }
        }
    }
}
