import React from 'react';

interface AsiakasLista_Tila {
    asiakkaat: any[];
}

class AsiakasLista extends React.Component<{}, AsiakasLista_Tila> {

    constructor() {
        super({});

        console.log("AsiakasLista.constructor()");
        this.state = { asiakkaat: [] };
    }

    componentDidMount() {
        console.log("AsiakasLista.componentDidMount()");

        console.log("AsiakasLista: aloitetaan Fetch-kutsu");

        fetch('http://dummy.restapiexample.com/api/v1/employees')
            .then(response => response.json())
            .then(json => {
                console.log("AsiakasLista: Fetch-kutsu valmis");
                console.log(json);

                console.log("AsiakasLista: Ennen tilan päivitystä");
                this.setState({ asiakkaat: json.data });
                console.log("AsiakasLista: Tila on päivitetty!");                
            });
    }

    render() {
        console.log("AsiakasLista.Render()");

        let rivit = [];
        for (let index = 0; index < this.state.asiakkaat.length; index++) {
            const työntekijä = this.state.asiakkaat[index];
            rivit.push(<tr key={index}>
                <td>{työntekijä.employee_name}</td>
                <td>{työntekijä.employee_age}</td>
            </tr>);
        }

        return <div>
            <h2>AsiakasLista</h2>
            <table>
                <thead>
                    <tr>
                        <th>Nimi</th>
                        <th>Ikä</th>
                    </tr>
                </thead>
                <tbody>
                    {rivit}
                </tbody>
            </table>
        </div>;
    }
}

export default AsiakasLista;