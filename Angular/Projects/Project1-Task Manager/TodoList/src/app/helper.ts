import { v4 as uuidv4 } from 'uuid';

export function generateShortId() {
  const id = uuidv4().split('-')[0];
  return id;
}
