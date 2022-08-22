import { Link, useLocation } from 'react-router-dom';

import MenuRoutes from '../content/MenuRoutes';

const Menu = () => {
	const location = useLocation();

	return (
		<div className="flex justify-between md:px-24 md:pt-16 md:items-center w-full">
      <h1>ToDo app</h1>
			<div className="menu block">
				<ul className="flex flex-col gap-2 text-blue md:flex-row justify-end">
					{MenuRoutes.map((route, index) => {
						const active = location.pathname === route.path ? 'active' : '';

						return (
							<Link key={index} to={route.path}>
								<li className={active}>{route.text}</li>
							</Link>
						);
					})}
				</ul>
			</div>
		</div>
	);
};

export default Menu;
