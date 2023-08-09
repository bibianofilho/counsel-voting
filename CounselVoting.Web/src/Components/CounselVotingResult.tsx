import { useEffect, useState } from "react";
import Table from "react-bootstrap/Table";
import Card from "react-bootstrap/Card";

function CounselVotingResult() {
  const API_URL = "http://localhost:14358";

  const [votingResult, setVotingResult] = useState({});
  const [names, setNames] = useState([]);

  useEffect(() => {
    getVotingResult(3);
  }, []);

  const getVotingResult = async (measureId: number) => {
    const response = await fetch(
      `${API_URL}/api/voteMeasure/${measureId}/result`
    );

    const data = await response.json();
    console.log(data);
    console.log(votingResult);
    console.log(votingResult.names);

    setVotingResult(data);
    setNames(data.names);
  };

  return (
    <Card>
      <Card.Header>Counsel Voting</Card.Header>
      <Card.Body>
        {votingResult.names == null ? (
          <Card.Title>There is no vote computed yet</Card.Title>
        ) : (
          <Card.Title>Result: {votingResult.result}</Card.Title>
        )}
        <div>
          <Table striped bordered hover>
            <thead>
              <tr>
                <th>#</th>
                <th>Name</th>
              </tr>
            </thead>
            <tbody>
              {names.map((name, index) => (
                <tr key={name}>
                  <td>{index + 1}</td>
                  <td>{name}</td>
                </tr>
              ))}
            </tbody>
          </Table>
        </div>
      </Card.Body>
    </Card>
  );
}

export default CounselVotingResult;
