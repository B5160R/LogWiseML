from flask import Flask, request

app = Flask(__name__)

@app.route('/api/dataset-collector', methods=['POST'])
def dataset_collector():
    if request.method == 'POST':
        # Get the string CSV data from the request
        csv_data = request.data.decode('utf-8')
        # Save the CSV data to a file
        with open('../Data/Datasets/dataset.csv', 'w') as f:
            f.write(csv_data)
        print(csv_data)
        return 'Dataset saved successfully'
    
    return 'Dataset not saved'

# @app.route('/api/run-model', methods=['POST'])
# def run_model():
