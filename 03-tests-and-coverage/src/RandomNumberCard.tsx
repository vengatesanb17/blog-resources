import './styles/main.css';

import * as React from 'react';

const RandomNumberCard = (): React.ReactElement => {
  const [rndNumb, setNum] = React.useState(0);

  return (
    <div
      className="RandomNumberCard"
      onClick={() => {
        const num = Math.floor(Math.random() * 100);
        setNum(num);
      }}
    >
      <h1 className="RandomNumberCard__title">Your random number was</h1>
      <p className="RandomNumberCard__number">{rndNumb}</p>
      <p>Can you guess the next one?</p>
    </div>
  );
};

export default RandomNumberCard;
