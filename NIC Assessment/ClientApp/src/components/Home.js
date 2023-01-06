import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { individuals: [], loading: false, fetchingFromDB: true };
    }

    static renderIndividualsTable(individuals) {
        return (
            <div style={{'overflow-x': 'auto'}} >
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Refrence Number</th>
                            <th>First Name</th>
                            <th>Second Name</th>
                            <th>Third Name</th>
                            <th>Fourth Name</th>
                            <th>Original Script Name</th>
                            <th>Listed On</th>
                        </tr>
                    </thead>
                    <tbody>
                        {individuals.map(individual =>
                            <tr key={individual.id}>
                                <td>{individual.referenceNo}</td>
                                <td>{individual.firstName}</td>
                                <td>{individual.secondName}</td>
                                <td>{individual.thirdName}</td>
                                <td>{individual.fourthName}</td>
                                <td>{individual.originalScriptName}</td>
                                <td>{individual.listedON}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }
    render() {
        let contents;
        if (this.state.loading) {
            contents = <div className="d-flex justify-content-center"><div className="spinner-border text-primary mx-2" role="status"><span className="sr-only">Loading...</span></div><p><em>Loading...</em></p></div>;
        }
        else if (this.state.fetchingFromDB) {
            contents = <p><em>Click "Load From Database"</em></p>;
        }
        else {
            contents = Home.renderIndividualsTable(this.state.individuals);
        }

        const populateDatabase = async () => {
            this.setState({ loading: true });
            const response = await fetch('LoadFromXML');
            this.setState({ loading: false });
        }

        const populateIndividualData = async () => {
            const response = await fetch('LoadFromDatabase');
            const data = await response.json();
            this.setState({ individuals: data, fetchingFromDB: false });
        }

        return (
            <div>
                <h1 id="tabelLabel" >Individual Information</h1>
                <div className="btn-group w-100 my-5">
                    <button type="button" onClick={ populateDatabase } className="btn btn-info rounded mx-5">Populate Database</button>
                    <button type="button" onClick={ populateIndividualData } className="btn btn-success rounded mx-5">Load From Database</button>
                </div>
                {contents}
            </div>
        );
    }

}
