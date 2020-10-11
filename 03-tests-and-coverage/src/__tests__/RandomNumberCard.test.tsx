import '@testing-library/jest-dom/extend-expect';

import { fireEvent, render } from '@testing-library/react';
import React from 'react';

import RandomNumberCard from '../RandomNumberCard';

describe('<RandomNumberCard />', () => {
  it('should start on 0', () => {
    const { container } = render(<RandomNumberCard />);
    const tag = container.getElementsByClassName('RandomNumberCard__number')[0];

    expect(tag.innerHTML).toEqual('0');
  });

  it('should change when clicked', () => {
    const { container } = render(<RandomNumberCard />);
    const card = container.getElementsByClassName('RandomNumberCard')[0];
    fireEvent.click(card);

    const tag = card.getElementsByClassName('RandomNumberCard__number')[0];

    expect(tag.innerHTML).not.toEqual('0');
  });
});
