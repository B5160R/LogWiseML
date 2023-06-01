from flask import Flask, request

app = Flask(__name__)

@app.route('/api/dataset-collector', methods=['POST'])
def dataset_collector():
    if request.method == 'POST':
        # Get the string CSV data from the request
        csv_data = request.data.decode('utf-8')
        # Save the CSV data to a file
        with open('../Models/LogErrorTime/Data/Datasets/dataset.csv', 'w') as f:
            f.write(csv_data)
        print(csv_data)
        return 'Dataset saved successfully'
    
    return 'Dataset not saved'

@app.route('/api/dataset', methods=['GET'])
def dataset():
    if request.method == 'GET':
        # Read the CSV data from the file
        with open('../Models/LogErrorTime/Data/Datasets/dataset.csv', 'r') as f:
            csv_data = f.read()
        return csv_data

    return 'Dataset not found'

@app.route('/api/run/testmodel', methods=['POST'])
def run_model():
    if request.method == 'POST':
        # Get the string CSV data from the request
        csv_data = request.data.decode('utf-8')
        with open('analysistdata.csv', 'w') as f:
            f.write(csv_data)

        import runModel
        
        result = runModel.run()

        #send result to rabbitmq queue
        import pika
        connection = pika.BlockingConnection(pika.ConnectionParameters(host='rabbitmq'))
        channel = connection.channel()
        channel.queue_declare(queue='log-error-time-model-result')
        channel.basic_publish(exchange='', routing_key='log-error-time-model-result', body=result)
        connection.close()
        
    
    return 'Error running test model'